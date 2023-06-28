# LiveScreenGPT

A software to convert your screen into text and send it to CHAT GPT with parameters

## Installation

To use this software, you need to have the following prerequisites:

- **.NET 6**: Ensure that you have .NET 6 installed on your system. You can download it from the official [.NET website](https://dotnet.microsoft.com/download/dotnet/6.0).

- **Tesseract**: Download Tesseract for Windows directly from [here](https://digi.bib.uni-mannheim.de/tesseract/) or check the official repository on GitHub: [Tesseract Repo](https://github.com/tesseract-ocr/tesseract). For proper functionality, you need to have the necessary language files installed for Tesseract. Visit the Tesseract repository and download the tessdata files, such as `eng.traineddata`, from [here](https://github.com/tesseract-ocr/tessdata_best/blob/main/eng.traineddata). Place the file inside the tessdata folder in the Tesseract installation directory.

- **OpenAI API Key**: Go to [OpenAI API Keys](https://platform.openai.com/account/api-keys) and create an API key that you will need for Chat GPT integration.

Once you have installed the prerequisites, you can proceed with the LiveScreen GPT installation. If you want to download just the executable app without the source code, you can find it in the root repository as [LiveScreenGPT.zip](https://github.com/fabioalmcosta/LiveScreenGPT/raw/main/LiveScreenGPT.zip).

## Usage

In the LiveScreen GPT settings, you have the following options:

- **Screen to use**: Choose the screen from which the data will come.
- **Language to OCR**: The language for Tesseract to translate the screen. Make sure you have the corresponding language installed in the Tesseract tessdata folder.
- **Tessdata location**: The location of the tessdata folder in the Tesseract installation. Default is: `C:/Program Files/Tesseract-OCR/tessdata`.
- **AI Expert**: A command you want to give to Chat GPT as an admin. (Before the main command and with an Admin role). For example: "Act as a software engineer expert."
- **Shortcut**: Create a keyboard shortcut to immediately check the screen. Click on "Record" and use your keyboard to set the shortcut.
- **The content has two columns checkbox**: Check this if your screen has two columns. For example, left column questions and right column multiple-choice list.
- **AI command**: The command you are going to give to Chat GPT. You can add an asterisk (*) where you want Tesseract to fill with the screen text.
- **GPT API Key**: Add the OpenAI API Key you created.

If you need further assistance, feel free to contact me at fabio.almcosta@gmail.com.

**Note**: Ensure that you have the necessary permissions and comply with OpenAI's terms of use when using the OpenAI API key.

## PrintScreens


![image](https://github.com/fabioalmcosta/LiveScreenGPT/assets/40249761/6437caec-2e86-479d-a2ac-b0d4fb40f5cb)
![image](https://github.com/fabioalmcosta/LiveScreenGPT/assets/40249761/f375d664-5558-4e99-8ec6-2dd2dcfb357b)


## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
