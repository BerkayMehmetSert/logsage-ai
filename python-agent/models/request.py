from pydantic import BaseModel

class LogAnalysisRequest(BaseModel):
    log: str
    query: str