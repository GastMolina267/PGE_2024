import pyttsx3

def speak_text(text):
    """Convierte el texto en voz."""
    engine = pyttsx3.init()
    engine.say(text)
    engine.runAndWait()
