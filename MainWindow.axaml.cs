using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace MiPresentacion
{
    public partial class MainWindow : Window
    {
        private int _tipoSaludo = 1;
        private bool _datosValidos = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnPresentarme_Click(object? sender, RoutedEventArgs e)
        {
            string nombre = TxtNombre.Text?.Trim() ?? string.Empty;
            string apellido = TxtApellido.Text?.Trim() ?? string.Empty;
            string edadTexto = TxtEdad.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MostrarMensajeError("Error: El nombre no puede estar vacío.");
                return;
            }

            if (string.IsNullOrWhiteSpace(apellido))
            {
                MostrarMensajeError("Error: El apellido no puede estar vacío.");
                return;
            }

            if (!int.TryParse(edadTexto, out int edad) || edad <= 0)
            {
                MostrarMensajeError("Error: Ingrese una edad válida (número entero positivo).");
                return;
            }
            _datosValidos = true;
            ActualizarMensajePresentacion(nombre, apellido, edad);
        }

        private void BtnCambiarSaludo_Click(object? sender, RoutedEventArgs e)
        {
            if (!_datosValidos)
            {
                MostrarMensajeError("Primero debe ingresar datos válidos y presionar 'Presentarme'.");
                return;
            }

            _tipoSaludo = _tipoSaludo == 1 ? 2 : 1;

            string nombre = TxtNombre.Text!.Trim();
            string apellido = TxtApellido.Text!.Trim();
            int edad = int.Parse(TxtEdad.Text!.Trim());

            ActualizarMensajePresentacion(nombre, apellido, edad);
        }

        private void BtnLimpiar_Click(object? sender, RoutedEventArgs e)
        {
            TxtNombre.Text = string.Empty;
            TxtApellido.Text = string.Empty;
            TxtEdad.Text = string.Empty;

            TxtResultado.Text = "Complete el formulario y presione 'Presentarme'.";
            TxtResultado.Foreground = Brushes.Black;

            _datosValidos = false;
            _tipoSaludo = 1;

            TxtNombre.Focus();
        }

        private void ActualizarMensajePresentacion(string nombre, string apellido, int edad)
        {
            TxtResultado.Foreground = Brushes.DarkGreen;

            if (_tipoSaludo == 1)
            {
                TxtResultado.Text = $"¡Hola! Mi nombre es {nombre} {apellido},\ntengo {edad} años y estoy aprendiendo\na desarrollar interfaces gráficas con C#.";
            }
            else
            {
                TxtResultado.Text = $"¡Saludos cordiales! Me presento: {nombre} {apellido}.\nCuenta con una edad de {edad} años\ny se encuentra explorando el desarrollo con Avalonia UI 11.";
            }
        }

        private void MostrarMensajeError(string mensaje)
        {
            _datosValidos = false;
            TxtResultado.Foreground = Brushes.Red;
            TxtResultado.Text = mensaje;
        }
    }
}
