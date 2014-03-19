// <summary>Implémentation de la classe <c>Crypt.Windows.App</c>.</summary>
// <author>Cédric Belin &lt;cedric@belin.io&gt;</author>

namespace Crypt.Windows {
  using System;
  using System.Globalization;
  using System.Linq;
  using System.Threading;
  using System.Windows;

  using Crypt.Windows.Properties;
  using Messages=Crypt.Windows.Properties.Resources;

  using MiniFramework.Reflection;
  using MiniFramework.Text;
  using MiniFramework.Windows;

  /// <summary>Application WPF.</summary>
  internal partial class App: Application {
  
    /// <summary>Initialise une nouvelle instance de la classe <see cref="App" />.</summary>
    public App() {
      this.Properties["Authors"]="Cédric Belin <cedric@belin.io>";
      this.Properties["License"]=OpenSourceLicenses.GnuGeneralPublicLicenseV3;
      this.Properties["Product"]=new AssemblyInfo(this.GetType().Assembly).Product;
    }

    /// <summary>Enregistre les paramètres de l'application.</summary>
    /// <param name="sender">Objet source de l'événement.</param>
    /// <param name="e">Objet contenant les données de l'événement.</param>
    private void OnApplicationExit(object sender, ExitEventArgs e) {
      Settings.Default.Save();
    }

    /// <summary>Définit la culture de l'application.</summary>
    /// <param name="sender">Objet source de l'événement.</param>
    /// <param name="e">Objet contenant les données de l'événement.</param>
    private void OnApplicationStartup(object sender, StartupEventArgs e) {
      // Détermination de la culture à utiliser pour l'affichage
      var culture=Settings.Default.Culture;
      var languages=Settings.Default.SupportedLanguages;

      if(culture.Equals(CultureInfo.InvariantCulture) || !languages.Contains(culture.TwoLetterISOLanguageName)) {
        var isoCode=(languages.Contains(CultureInfo.CurrentUICulture.TwoLetterISOLanguageName)) ?
          CultureInfo.CurrentUICulture.TwoLetterISOLanguageName : Settings.Default.SupportedLanguages[0];

        culture=CultureInfo.CreateSpecificCulture(isoCode);
      }

      // Définition de la culture
      Thread.CurrentThread.CurrentCulture=culture;
      Thread.CurrentThread.CurrentUICulture=culture;

      // Validation de l'installation
      this.CheckSetup();
    }

    /// <summary>Vérifie que toutes les conditions sont réunies pour le démarrage de l'application.</summary>
    /// <remarks>Si aucun codeur de chaîne ne peut être trouvé, un message est affiché à l'utilisateur et l'application arrêtée.</remarks>
    private void CheckSetup() {
      if(EncoderManager.Encoders.Count==0) {
        var message=Messages.AddInsNotFoundError.Split('|');
        TaskDialog.Show(null, message[1], message[0], null, MessageBoxButton.OK, MessageBoxImage.Error);
        this.Shutdown(1);
      }
    }
  }
}