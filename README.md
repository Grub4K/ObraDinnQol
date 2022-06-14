# ObraDinnQol
Quality of life patches for the game "Return of the Obra Dinn"

## Installation
This is a BepInEx plugin. To install:
- Download the latest release of BepInEx (x86) from [here](https://github.com/BepInEx/BepInEx/releases/latest)
- Extract the file so that the `BepInEx` folder is located in the `ObraDinn` game folder
- Download the `ObraDinn.QolPatches.dll` from the [releases](https://github.com/Grub4K/ObraDinnQol/releases/latest)
- Place the `ObraDinn.QolPatches.dll` in the `BepInEx/plugins` folder
    - You might have to run the game once for it to create these folders

## Usage
After running the game with the plugin installed at least once, there will be a config file created in the `BepInEx/config` directory (`ObraDinn.QolPatches.cfg`).
Edit the file with any text editor, all the customizable options are described in there.

## Building
Clone the repo and put the referenced dll (`Assembly-CSharp.dll`) from the game directory into the `lib/` folder.
Then run `dotnet build -c Release -o bin` to create a directory `bin/` containing the `ObraDinn.QolPatches.dll`.
