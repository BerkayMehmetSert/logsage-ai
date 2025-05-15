from fastapi import APIRouter, HTTPException
from models.request import LogAnalysisRequest
from models.response import LogAnalysisResponse
from services.llm_client import analyze_logs
import traceback

router = APIRouter()

@router.post("/analyze", response_model=LogAnalysisResponse)
def analyze(req: LogAnalysisRequest):
    try:
        result = analyze_logs(req.log, req.query)
        return LogAnalysisResponse(result=result)
    except Exception as e:
        error_detail = f"Error: {str(e)}\n{traceback.format_exc()}"
        print(error_detail)  # Log the error for debugging
        raise HTTPException(status_code=500, detail=error_detail)
