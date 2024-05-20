# Custom RSI Indicator for Quantower

This project implements a custom RSI indicator with EMA39 and SMA9 calculations, as well as customized colorized levels for the Quantower trading platform.

## Features
- RSI calculation with a customizable period.
- EMA39 and SMA9 calculations based on RSI values.
- Colorized RSI levels:
  - 85-67: Blue
  - 67-63: White
  - 63-50: Gray
  - 50-38: Blue
  - 38-34: White
  - 34-15: Gray

## Installation
1. Clone this repository.
2. Open the project in Visual Studio.
3. Build the project to create the custom indicator DLL.
4. Load the DLL into Quantower.

## Usage
1. Open Quantower and go to the indicators panel.
2. Load the `Custom RSI Indicator` from the list of available indicators.
3. Configure the RSI, EMA, and SMA periods as needed.

## License
This project is licensed under the MIT License.
