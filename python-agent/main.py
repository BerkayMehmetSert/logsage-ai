from fastapi import FastAPI
from routers import analyze

app = FastAPI(title="LogSage Python Agent")

app.include_router(analyze.router)
