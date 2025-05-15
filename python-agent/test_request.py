import requests
import json

# Sample log data
log_data = """
2023-05-15 10:23:45 INFO Server started successfully
2023-05-15 10:24:12 INFO User login: user123
2023-05-15 10:25:30 WARNING High memory usage detected: 85%
2023-05-15 10:26:45 ERROR Database connection failed
2023-05-15 10:27:10 INFO Retry database connection
2023-05-15 10:27:15 INFO Database connection established
2023-05-15 10:30:22 INFO User logout: user123
"""

# Query about the log
query = "What errors occurred in the log and were they resolved?"

# Create the request payload
payload = {
    "log": log_data,
    "query": query
}

# Send the request to the API
response = requests.post("http://localhost:8000/analyze", json=payload)

# Print the response
print("Status Code:", response.status_code)
print("Response (JSON):")
print(json.dumps(response.json(), indent=2, ensure_ascii=False))

# Print the raw text response for better readability of Turkish characters
print("\nResponse (Raw Text):")
print(response.json()["result"])
