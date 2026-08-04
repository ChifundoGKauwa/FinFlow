import os
from dotenv import load_dotenv

load_dotenv()
Data= os.getenv("DATABASE_URL")
access_key= os.getenv("ACCESS_KEY")
secret_key=os.getenv("SECRET_KEY")
minio_endpoint=os.getenv("END_POINT")

