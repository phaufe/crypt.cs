// <summary>Implémentation de la classe <c>Crypt.Windows.MainWindow</c>.</summary>
// <author>Cédric Belin &lt;cedric@belin.io&gt;</author>

namespace Crypt.Windows {
  using System;
  using System.Collections.Generic;
  using System.Globalization;
  using System.Linq;
  using System.Windows;
  using System.Windows.Controls;
  using System.Windows.Controls.Primitives;
  using System.Windows.Input;

  using Crypt.Windows.Properties;
  using Messages=Crypt.Windows.Properties.Resources;

  using MiniFramework;
  using MiniFramework.Drawing;
  using MiniFramework.Reflection;
  using MiniFramework.Text;
  using MiniFramework.Windows;

  /// <summary>Fenêtre principale.</summary>
  public partial class MainWindow: Window {
  
    /// <summary>La commande &quot;Afficher/masquer un contrôle&quot;.</summary>
    public static readonly RoutedUICommand ShowHideCommand=new RoutedUICommand();

    /// <summary>Initialise une nouvelle instance de la classe <see cref="MainWindow" />.</summary>
    public MainWindow() {
      // Initialisation de l'interface graphique
      this.InitializeComponent();

      // Contrôles de sélection de la culture
      foreach(var item in Settings.Default.SupportedLanguages) this.CultureMenu.Cultures.AddLanguage(item, false);
      this.CultureMenu.SelectedCulture=CultureInfo.CurrentUICulture;
      this.CultureMenu.SelectedCultureChanged+=this.OnSelectedCultureChanged;

      var cultureButton=this.CultureMenu.ToCultureButton();
      cultureButton.Tag="CultureControlStatusTip";
      this.ToolBar.Items.Insert(this.ToolBar.Items.IndexOf(this.AboutButton), cultureButton);

      // Messages de la barre d'état : élements du menu
      var product=Application.Current.Properties["Product"].ToString();

      foreach(MenuItem topLevelItem in this.MenuBar.Items) {
        foreach(var item in topLevelItem.Items.OfType<MenuItem>()) {
          var property=(item.Tag!=null) ? item.Tag.ToString() : ((RoutedCommand) item.Command).Name+"CommandStatusTip";
          
          var text=Reflector.GetPropertyValue(typeof(Messages), property).ToString();
          if(text.Contains("{0}")) text=string.Format(CultureInfo.CurrentCulture, text, product);

          this.SetStatusTip(item, text);
        }
      }

      // Messages de la barre d'état : boutons de la barre d'outils
      foreach(var item in this.ToolBar.Items.OfType<ButtonBase>()) {
        var property=(item.Tag!=null) ? item.Tag.ToString() : ((RoutedCommand) item.Command).Name+"CommandStatusTip";
          
        var text=Reflector.GetPropertyValue(typeof(Messages), property).ToString();
        if(text.Contains("{0}")) text=string.Format(CultureInfo.CurrentCulture, text, product);

        this.SetStatusTip(item, text);
      }

      // Messages de la barre d'état : contrôles de la fenêtre
      this.SetStatusTip(this.EncodeButton, Messages.EncodeButtonStatusTip);
      this.SetStatusTip(this.InputTextBox, Messages.InputTextBoxStatusTip);
      this.SetStatusTip(this.InputComboBox, Messages.InputComboBoxStatusTip);
      this.SetStatusTip(this.OutputTextBox, Messages.OutputTextBoxStatusTip);
    }

    /// <summary>Affiche la boîte de dialogue &quot;A propos&quot;.</summary>
    /// <param name="sender">Objet source de l'événement.</param>
    /// <param name="e">Objet contenant les données de l'événement.</param>
    private void OnAboutExecuted(object sender, ExecutedRoutedEventArgs e) {
      var window=new AboutBox() {
        Authors=Application.Current.Properties["Authors"].ToString(),
        Copyright=string.Format(CultureInfo.CurrentCulture, Messages.ApplicationCopyright, new AssemblyInfo(this.GetType().Assembly).Copyright),
        Description=Messages.ApplicationDescription,
        Logo=Properties.Resources.ApplicationIcon.ToBitmapImage(48),
        License=(License) Application.Current.Properties["License"],
        Owner=this,
        WebSite=Settings.Default.WebSite
      };

      window.ShowDialog();
    }

    /// <summary>Ferme la fenêtre.</summary>
    /// <param name="sender">Objet source de l'événement.</param>
    /// <param name="e">Objet contenant les données de l'événement.</param>
    private void OnCloseExecuted(object sender, ExecutedRoutedEventArgs e) {
      this.Close();
      e.Handled=true;
    }

    /// <summary>Ouvre une URL dans le navigateur par défaut.</summary>
    /// <param name="sender">Objet source de l'événement.</param>
    /// <param name="e">Objet contenant les données de l'événement.</param>
    private void OnOpenUrlExecuted(object sender, ExecutedRoutedEventArgs e) {
      new Uri(Settings.Default.WebSite, e.Parameter as Uri).Open();
      e.Handled=true;
    }

    /// <summary>Affiche ou masque un contrôle.</summary>
    /// <param name="sender">Objet source de l'événement.</param>
    /// <param name="e">Objet contenant les données de l'événement.</param>
    private void OnShowHideExecuted(object sender, ExecutedRoutedEventArgs e) {
      if(e.Parameter!=null) {
        var control=this.FindName(e.Parameter.ToString()) as Control;
        if(control!=null) control.Visibility=(control.IsVisible) ? Visibility.Collapsed : Visibility.Visible;
        e.Handled=true;
      }
    }

    /// <summary>Affiche le texte associé à un contrôle dans la barre d'état.</summary>
    /// <param name="sender">Objet source de l'événement.</param>
    /// <param name="e">Objet contenant les données de l'événement.</param>
    private void OnControlMouseEnter(object sender, MouseEventArgs e) {
      this.StatusImage.Visibility=Visibility.Visible;
    }

    /// <summary>Réinitialise la barre d'état.</summary>
    /// <param name="sender">Objet source de l'événement.</param>
    /// <param name="e">Objet contenant les données de l'événement.</param>
    private void OnControlMouseLeave(object sender, MouseEventArgs e) {
      this.StatusImage.Visibility=Visibility.Hidden;
      this.StatusLabel.Text=string.Empty;
    }

    /// <summary>Code la chaîne du champ d'entrée et place le résultat dans le champ de sortie.</summary>
    /// <param name="sender">Objet source de l'événement.</param>
    /// <param name="e">Objet contenant les données de l'événement.</param>
    private void OnEncodeButtonClick(object sender, RoutedEventArgs e) {
      this.OutputTextBox.Text=EncoderManager.Encoders[this.InputComboBox.SelectedIndex].Encode(this.InputTextBox.Text);
      e.Handled=true;
    }

    /// <summary>Change la langue de l'application et la redémarre.</summary>
    /// <param name="sender">Objet source de l'événement.</param>
    /// <param name="e">Objet contenant les données de l'événement.</param>
    private void OnSelectedCultureChanged(object sender, DependencyPropertyChangedEventArgs e) {
      var message=Messages.RestartProgramInfo.Split('|');
      TaskDialog.Show(null, message[1], message[0], null, MessageBoxButton.OK, MessageBoxImage.Information);

      Settings.Default.Culture=this.CultureMenu.SelectedCulture;
      Application.Current.Restart();
    }

    /// <summary>Définit le texte à afficher dans la barre d'état lorsque la souris passe au-dessus du contrôle spécifié.</summary>
    /// <param name="control">Contrôle associé au texte spécifié.</param>
    /// <param name="text">Texte à afficher dans la barre d'état.</param>
    /// <exception cref="ArgumentNullException">Le contrôle spécifié est une référence null.</exception>
    private void SetStatusTip(Control control, string text) {
      if(control==null) throw new ArgumentNullException("control");
      control.MouseEnter+=this.OnControlMouseEnter;
      control.MouseEnter+=delegate { this.StatusLabel.Text=text; };
      control.MouseLeave+=this.OnControlMouseLeave;
    }
  }
}