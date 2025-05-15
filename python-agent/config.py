from dotenv import load_dotenv
import os

load_dotenv()

class Settings:
    OPENROUTER_API_KEY = os.getenv("OPENROUTER_API_KEY")
    OPENROUTER_BASE_URL = os.getenv("OPENROUTER_BASE_URL", "https://openrouter.ai/api/v1")
    LLM_MODEL = os.getenv("LLM_MODEL", "mistralai/mixtral-8x7b-instruct")

settings = Settings()