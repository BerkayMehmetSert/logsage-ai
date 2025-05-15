@echo off
echo Building and starting LogSage Python Agent in Docker...
docker-compose up -d
echo.
echo LogSage Python Agent is now running at http://localhost:8000
echo.
echo To test the API, run: docker-compose exec logsage-api python test_request.py
echo To stop the container, run: docker-compose down