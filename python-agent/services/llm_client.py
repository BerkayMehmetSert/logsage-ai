from openai import OpenAI
from config import settings
from prompts.templates import build_prompt
import os
import dotenv
import pathlib

def analyze_logs(log: str, query: str) -> str:
    # Get the absolute path to the .env file
    env_path = pathlib.Path(__file__).parent.parent / '.env'
    print(f"Looking for .env file at: {env_path.absolute()}")

    # Check if the .env file exists
    if not env_path.exists():
        raise ValueError(f".env file not found at {env_path.absolute()}. Please create it with the required environment variables.")

    # Force reload the .env file to ensure we have the latest values
    dotenv.load_dotenv(dotenv_path=env_path, override=True)

    prompt = build_prompt(log, query)

    # Debug: Print environment variables to verify they're loaded
    print("Environment variables after loading .env:")
    print(f"OPENROUTER_API_KEY exists: {'OPENROUTER_API_KEY' in os.environ}")
    print(f"OPENROUTER_BASE_URL: {os.getenv('OPENROUTER_BASE_URL')}")
    print(f"LLM_MODEL: {os.getenv('LLM_MODEL')}")

    # Use the API key from the .env file directly
    api_key = "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"
    base_url = "https://openrouter.ai/api/v1"
    model = "mistralai/mixtral-8x7b-instruct"

    # Create the OpenAI client with the API key
    client = OpenAI(
        api_key=api_key,
        base_url=base_url
    )

    response = client.chat.completions.create(
        model=model,
        messages=[{"role": "user", "content": prompt}]
    )

    return response.choices[0].message.content
