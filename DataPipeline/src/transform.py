import polars as pl

def Tranformation(*tables:dict[str,pl.DataFrame])->pl.DataFrame:
    cleaned_tables=[]
    for idx , df in enumerate(tables):
        print(f"validating and cleaning table:'{idx}'...")
        processed_df=(
            df
            .unique()
            .drop_nulls()
        )
        cleaned_tables.append(processed_df)
        print(f"Table index '{idx}' successfully cleaned.Remaining rows :{processed_df.height}")
    return cleaned_tables  