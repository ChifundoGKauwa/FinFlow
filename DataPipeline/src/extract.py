import polars as pl
from sqlalchemy import create_engine

class extractor:
    def __init__(self,database_url:str):
        self.engine = create_engine(database_url)
    def extract_table(self,table:str)->pl.DataFrame:
        query= f'select * from "{table}"'
        return pl.read_database(
            query=query,
            connection = self.engine
        )

