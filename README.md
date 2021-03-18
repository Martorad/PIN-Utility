# PIN Utility
![logo](PIN.png)

PIN Utility is an app that has been in ongoing development by me since the 4th of August, 2020. It is an app that came out of necessity. It is extremely specialized to do a single job and to do it well.
### 1. Context

How do you enter a very large quantity of codes in picture format into a text-based database? Surely, the first thing that comes to mind is Optical Character Recognition (OCR). Now, what if the margin for error of these codes is none. Your average Tesseract OCR distro can run at an accuracy of 85%. Do some pre-formatting on your images, and you can get that up to 95%. Do some basic machine learning and you can go up to 99%+ accuracy. But that still isn't enough. This is where PIN Utility comes in.
### 2. How it works

By simultaneously using a trained Tesseract, along with the PIN Utility, in which a human operator enters the codes, one can compare both datasets for differences and thus achieve an accuracy of ~100%. The beauty of it all comes in the fact that very rarely do humans and robots make the same kind of error. Where the OCR may confuse a 'B' for an '8', or an 'I' for a '1', the most common human errors are in swapping adjacent characters, such as "HMNG" to "HNMG". This allows both datasets to correct each other.
### 3. Why was this needed?

Before this method was devised, this was all done manually. Instead of having an OCR and a human operator, 2 human operators would be used to enter one batch of codes. This method is far less accurate, as both operators are much more likely to make the same error in the same place. Additionally, there wasn't a PIN Utility at all, instead a simple Excel spreadsheet was used to enter batches of thousands of codes. By using my app, the accuracy of the human operator has went up from a mere 97% to 99,3%. This is due to the less clutter on screen, the UP-DOWN positioning of the codes instead of Excel's side-to-side and most importantly - an overlay which automatically appears over the picture code as the user inputs it, allowing them to instantly spot when an error has been made.
### 4. Final notes

The app has been through 4 major versions, with the most recent being the most complete - version 1.0. Before this were versions 0.1, 0.2 and 0.3, each with their own subversions. These featured small new features, bugfixes, code optimizations and general quality-of-life improvements.