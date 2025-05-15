def build_prompt(log: str, query: str) -> str:
    return f"""
You are a log analysis assistant. Analyze the logs below and answer this question: "{query}"
Please provide your response in Turkish language.

Logs:
{log}
"""
