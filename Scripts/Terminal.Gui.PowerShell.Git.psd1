#
# Module manifest for module 'Terminal.Gui.PowerShell.Git'
#
# Generated by: Brandon Thetford
#
# Generated on: 4/26/2024
#

@{

# Script module or binary module file associated with this manifest.
RootModule = ''

# Version number of this module.
ModuleVersion = '1.0.0'

# Supported PSEditions
CompatiblePSEditions = 'Core'

# ID used to uniquely identify this module
GUID = '33a6c4c9-c0a7-4c09-b171-1da0878f93ea'

# Author of this module
Author = 'Brandon Thetford (GitHub @dodexahedron)'

# Company or vendor of this module
CompanyName = 'The Terminal.Gui Project'

# Copyright statement for this module
Copyright = 'Brandon Thetford (GitHub @dodexahedron), provided to the Terminal.Gui project and you under the MIT license'

# Description of the functionality provided by this module
Description = 'Simple helper commands for common git operations.'

# Minimum version of the PowerShell engine required by this module
PowerShellVersion = '7.4'

# Name of the PowerShell host required by this module
PowerShellHostName = 'ConsoleHost'

# Minimum version of the PowerShell host required by this module
PowerShellHostVersion = '7.4.0'

# Processor architecture (None, MSIL, X86, IA64, Amd64, Arm, or an empty string) required by this module. One value only.
# Set to AMD64 here because development on Terminal.Gui isn't really supported on anything else.
# Has nothing to do with runtime use of Terminal.Gui.
ProcessorArchitecture = 'AMD64'

# Modules that must be imported into the global environment prior to importing this module
RequiredModules = @(
    @{
        ModuleName='Microsoft.PowerShell.Utility'
        ModuleVersion='7.0.0'
    },
    @{
        ModuleName='Microsoft.PowerShell.Management'
        ModuleVersion='7.0.0'
    },
    @{
        ModuleName='PSReadLine'
        ModuleVersion='2.3.4'
    }
)

# Script files (.ps1) that are run in the caller's environment prior to importing this module.
ScriptsToProcess = @()

# Type files (.ps1xml) to be loaded when importing this module
TypesToProcess = @()

# Format files (.ps1xml) to be loaded when importing this module
FormatsToProcess = @()

# Modules to import as nested modules.
NestedModules = @("./Terminal.Gui.PowerShell.Git.psm1")

# Functions to export from this module.
FunctionsToExport = @('New-GitBranch')

# Cmdlets to export from this module, for best performance, do not use wildcards and do not delete the entry, use an empty array if there are no cmdlets to export.
CmdletsToExport = @()

# Variables to export from this module
VariablesToExport = @()

# Aliases to export from this module, for best performance, do not use wildcards and do not delete the entry, use an empty array if there are no aliases to export.
AliasesToExport = @()

# DSC resources to export from this module
DscResourcesToExport = @()

# List of all modules packaged with this module
ModuleList = @('./Terminal.Gui.PowerShell.Git.psm1')

# Private data to pass to the module specified in RootModule/ModuleToProcess. This may also contain a PSData hashtable with additional module metadata used by PowerShell.
PrivateData = @{

    PSData = @{

        # Tags applied to this module. These help with module discovery in online galleries.
        # Tags = @()

        # A URL to the license for this module.
        # LicenseUri = ''

        # A URL to the main website for this project.
        # ProjectUri = ''

        # A URL to an icon representing this module.
        # IconUri = ''

        # ReleaseNotes of this module
        # ReleaseNotes = ''

        # Prerelease string of this module
        # Prerelease = ''

        # Flag to indicate whether the module requires explicit user acceptance for install/update/save
        # RequireLicenseAcceptance = $false

        # External dependent modules of this module
        # ExternalModuleDependencies = @()

    } # End of PSData hashtable

} # End of PrivateData hashtable

# HelpInfo URI of this module
# HelpInfoURI = ''

# Default prefix for commands exported from this module. Override the default prefix using Import-Module -Prefix.
# DefaultCommandPrefix = ''

}
