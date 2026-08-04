from pathlib import Path
import polars as pl
from minio import Minio
from config import access_key,secret_key,minio_endpoint

class ParquetLoader:
    def __init__(self):
        self.client=Minio(
            minio_endpoint,
            access_key=access_key,
            secret_key=secret_key,
            secure=False,
        )

    def write(self, df: pl.DataFrame, layer: str, table: str):
        # Create local temporary directory
        path = Path(f"data/{layer}/{table}")
        path.mkdir(parents=True, exist_ok=True)

        # Define the parquet file path
        file_path = path / f"{table}.parquet"

        # Write parquet locally
        df.write_parquet(file_path)

        # Create bucket if it doesn't exist
        if not self.client.bucket_exists(layer):
            self.client.make_bucket(layer)

        # Upload to MinIO
        self.client.fput_object(
            bucket_name=layer,
            object_name=f"{table}/{table}.parquet",
            file_path=str(file_path),
        )

        print(f"Uploaded {table}.parquet to {layer}/{table}")