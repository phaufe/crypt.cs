#define AppExeName "crypt.windows.exe"
#define AppName "Crypt.cs"
#define AppPublisher "Cédric Belin"
#define AppURL "https://github.com/cedx/crypt.cs"
#define AppVersion "0.4.0"

[Setup]
AppCopyright = Copyright (c) 2009-2014 {#AppPublisher}
AppId = {{CA46E55B-8587-4F14-81A5-699D4DED86EF}
AppName = {#AppName}
AppPublisher = {#AppPublisher}
AppPublisherURL = http://belin.io
AppSupportURL = {#AppURL}/issues
AppVerName = {#AppName} {#AppVersion}
AppVersion = {#AppVersion}

AllowNoIcons = yes
ArchitecturesInstallIn64BitMode = x64
Compression = lzma
DefaultDirName = {pf}\Belin\{#AppName}
DefaultGroupName = {#AppName}
LicenseFile = .\LICENSE.txt
OutputBaseFilename = {#AppName} {#AppVersion}
OutputDir = .\var
SetupIconFile = .\src\crypt.windows\resources\app.ico
SolidCompression = yes
UninstallDisplayIcon = {app}\{#AppExeName}
VersionInfoVersion = 5.5.5
WizardImageFile = compiler:WizModernImage-IS.bmp
WizardSmallImageFile = .\setup.bmp

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "french"; MessagesFile: "compiler:Languages\French.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 6.1

[Files]
Source: ".\var\release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\{#AppName}"; Filename: "{app}\{#AppExeName}"; WorkingDir: "{userdocs}"
Name: "{group}\{cm:ProgramOnTheWeb,{#AppName}}"; Filename: "{#AppURL}"
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#AppName}"; Filename: "{app}\{#AppExeName}"; Tasks: quicklaunchicon
Name: "{userdesktop}\{#AppName}"; Filename: "{app}\{#AppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#AppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(AppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
