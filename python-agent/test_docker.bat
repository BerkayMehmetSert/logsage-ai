@echo off
echo Testing LogSage Python Agent API in Docker...
echo.
docker-compose exec logsage-api python test_request.py
echo.
echo Test completed.