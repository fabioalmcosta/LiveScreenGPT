# LiveScreenGPT

A software to convert your screen into text and send it to CHAT GPT with parameters

## Installation

To use this software, you need to have Tesseract installed before using it:

- Download Tesseract for Windows directly from [here](https://digi.bib.uni-mannheim.de/tesseract/), or check the official repository on GitHub: [Tesseract Repo](https://github.com/tesseract-ocr/tesseract)
- For proper functionality, you need to have the necessary language files installed for Tesseract. Visit the Tesseract repository and download the tessdata files, such as `eng.traineddata`, from [here](https://github.com/tesseract-ocr/tessdata_best/blob/main/eng.traineddata). Place the file inside your tessdata inside Tesseract installation folder.

You will also need an OpenAI API key. Follow these steps:

1. Go to [OpenAI API Keys](https://platform.openai.com/account/api-keys)
2. Create an API key that you will need for Chat GPT

Once you have completed the above steps, you can proceed with the LiveScreen GPT installation. When you open the application, click on the "Settings" button.

## Usage

In the LiveScreen GPT settings, you have the following options:

- **Screen to use**: Choose the screen from which the data will come.
- **Language to OCR**: The language for Tesseract to translate the screen. Make sure you have the corresponding language installed in the Tesseract tessdata folder.
- **Tessdata location**: The location of the tessdata folder in the Tesseract installation. Default is: `C:/Program Files/Tesseract-OCR/tessdata`
- **AI Expert**: A command you want to give to Chat GPT as an admin. (Before the main command and with an Admin role). For example: "Act as a software engineer expert."
- **Shortcut**: Create a keyboard shortcut to immediately check the screen. Click on "Record" and use your keyboard to set the shortcut.
- **The content has two columns checkbox**: Check this if your screen has two columns. For example, left column questions and right column multiple choice list.
- **AI command**: The command you are going to give to Chat GPT. You can add an asterisk (*) where you want Tesseract to fill with the screen text.
- **GPT API Key**: Add the OpenAI API Key you created.

If you need more help, feel free to contact me at fabio.almcosta@gmail.com.

**Note**: Ensure that you have the necessary permissions and comply with OpenAI's terms of use when using the OpenAI API key.
