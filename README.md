# LogSage AI

## Genel Bakış
LogSage AI, .NET ve Python (FastAPI) kullanarak log dosyalarını analiz eden güçlü bir uygulamadır. Büyük Dil Modelleri (LLM'ler) kullanarak akıllı log yorumlama sağlar. Kullanıcılar log dosyalarını yükleyebilir ve belirli sorular sorarak hızlı bir şekilde sorunları, hataları ve çözümlerini tespit edebilirler.

## Teknoloji Yığını

### Backend (.NET)
- .NET 8
- ASP.NET Core Web API
- Docker
- HttpClient
- Swashbuckle (Swagger)

### Python Agent
- Python 3.9
- FastAPI
- OpenAI API (OpenRouter aracılığıyla)
- Docker
- Pydantic

## Özellikler
- Log dosyası yükleme
- Sorgu tabanlı log analizi
- LLM kullanarak gerçek zamanlı log yorumlama
- Swagger aracılığıyla interaktif API dokümantasyonu
- Docker Compose ile kolay dağıtım

## Proje Yapısı
```
logsage-ai/
├── dotnet-api/
│   └── LogSage.Api/
│       ├── Application/
│       │   ├── Interfaces/
│       │   └── Services/
│       ├── Controllers/
│       ├── Extensions/
│       ├── Filters/
│       ├── Infrastructure/
│       │   └── HttpClients/
│       ├── appsettings.json
│       ├── Dockerfile
│       └── Program.cs
├── python-agent/
│   ├── models/
│   │   ├── request.py
│   │   └── response.py
│   ├── routers/
│   │   └── analyze.py
│   ├── services/
│   │   └── llm_client.py
│   ├── prompts/
│   │   └── templates.py
│   ├── config.py
│   ├── main.py
│   ├── requirements.txt
│   ├── Dockerfile
│   └── .env
├── examples/
│   └── logs/
├── docker-compose.yml
└── .gitignore
```

## Kurulum

### Gereksinimler
- Docker ve Docker Compose
- .NET SDK 8
- Python 3.9

### Ortam Değişkenleri
`python-agent` klasöründe aşağıdaki içeriğe sahip bir `.env` dosyası oluşturun:
```
OPENROUTER_API_KEY=your-openrouter-api-key
OPENROUTER_BASE_URL=https://openrouter.ai/api/v1
LLM_MODEL=mistralai/mixtral-8x7b-instruct
```

### Kurulum ve Çalıştırma

#### Docker Compose

Proje dizinine gidin:
```bash
docker-compose up --build
```

Erişim:
- .NET API: `http://localhost:5000`
- Python Agent: `http://localhost:8000`

## API Kullanımı

### Logları Analiz Etme

#### İstek
`POST http://localhost:5000/api/loganalysis/analyze`

Form Verileri:
- `File`: Log dosyası
- `Query`: Metin tabanlı sorgu

#### Örnek İstek
```bash
curl -X POST "http://localhost:5000/api/loganalysis/analyze" \
     -F "file=@./examples/logs/sample.log" \
     -F "query=Loglarda hangi hatalar meydana gelmiş ve çözüme ulaşılmış mı?"
```

#### Yanıt
```json
{
  "result": "Analiz sonucu metni...",
  "pretty": "Biçimlendirilmiş analiz sonucu..."
}
```

## Geliştirme

### Swagger Dokümantasyonu
Swagger UI'a `http://localhost:5000/swagger` adresinden erişebilirsiniz.

## Docker İmajları
- .NET API `5000` portunu dinler
- Python agent `8000` portunu dinler
