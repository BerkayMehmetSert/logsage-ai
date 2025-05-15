# LogSage Python Agent

This is a FastAPI application that analyzes logs using LLM (Large Language Model) capabilities.

## Setup

### Standard Setup

1. Make sure you have Python installed on your system.

2. Install the required dependencies:
   ```
   pip install -r requirements.txt
   ```

3. Ensure your `.env` file is properly configured with the following variables:
   ```
   OPENROUTER_API_KEY=your_api_key
   OPENROUTER_BASE_URL=https://openrouter.ai/api/v1
   LLM_MODEL=mistralai/mixtral-8x7b-instruct
   ```

### Docker Setup

1. Make sure you have Docker and Docker Compose installed on your system.

2. Ensure your `.env` file is properly configured as mentioned in the Standard Setup.

3. Build and start the Docker container using one of these methods:

   a. Using the provided script:
   ```
   start_docker.bat
   ```

   b. Using Docker Compose directly:
   ```
   docker-compose up -d
   ```

4. The server will start at `http://localhost:8000`

5. To stop the container, use one of these methods:

   a. Using the provided script:
   ```
   stop_docker.bat
   ```

   b. Using Docker Compose directly:
   ```
   docker-compose down
   ```

## Running the Application

### Standard Method

1. Start the server by running the `start_server.bat` file or using the command:
   ```
   uvicorn main:app --reload
   ```

2. The server will start at `http://localhost:8000`

## Testing the API

### Standard Method

1. After starting the server, you can test the API by running the `run_test.bat` file or using the command:
   ```
   python test_request.py
   ```

2. This will send a sample log analysis request to the API and print the response.

### Docker Method

1. After starting the Docker container, you can test the API using one of these methods:

   a. Using the provided script:
   ```
   test_docker.bat
   ```

   b. Using Docker Compose directly:
   ```
   docker-compose exec logsage-api python test_request.py
   ```

2. Alternatively, you can test from your host machine using the test_request.py script or any HTTP client as described in the Manual Testing section.

## API Endpoints

- **POST /analyze**: Analyzes logs based on a query
  - Request body:
    ```json
    {
      "log": "your log content here",
      "query": "your question about the logs"
    }
    ```
  - Response:
    ```json
    {
      "result": "analysis result from the LLM"
    }
    ```

## Manual Testing

You can also test the API using tools like curl, Postman, or any HTTP client:

```bash
curl -X POST "http://localhost:8000/analyze" \
     -H "Content-Type: application/json" \
     -d '{
           "log": "2023-05-15 10:23:45 INFO Server started\n2023-05-15 10:26:45 ERROR Database connection failed",
           "query": "What errors occurred in the log?"
         }'
```
