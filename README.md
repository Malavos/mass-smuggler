# mass-smuggler
RavenDB Mass Smuggler - Simple tool for exporting all RavenDB databases with one command.

# Getting started

- Download the files in de `dist` folder and save them on your machine/server.
- Navigate to the folder where you placed the files via your terminal.
- Enter the commands to use the mass smuggler.

# Commands

```
# Export all databases
Command: Mass.Smuggler.exe --export --all --url <url Raven Database server> --path <path to save export files too>
Example: Mass.Smuggler.exe --export --all --url http://localhost:8080 --path c:\backups\

# Help information
Command: Mass.Smuggler.exe --help
Example output:

    Export
    --export           :   [required] Export database(s)
    --all              :   [required] Select all databases
    --url  <value>     :   [required] Raven DB server instance URL
    --path <value>     :   [required] Ravendump files destination path

    Other
    --help             :   Show helping information
```
