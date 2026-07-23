import polars as pl

def Validation(*tables:pl.DataFrame)->list[pl.DataFrame]:
    validated_tables=[]
    for idx,df in enumerate(tables):
        print(f"\n Profiling Table Index {idx}")
        print("rows",df.height)
        print("columns",df.width)
        print("null counts:",df.null_count())
        print("schema:",df.schema)

    return validated_tables