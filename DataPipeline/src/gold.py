import polars as pl

def gold_layer(cleaned_accounts:pl.DataFrame,cleaned_transactions:pl.DataFrame,cleaned_cutsomers:pl.DataFrame):
    dim_customers = cleaned_cutsomers.select([
        pl.col("Id").alias("CustomerId"),"FirstName","LastName","Email","CreatedAt"

    ])

    dim_accounts= cleaned_accounts.select([
        pl.col("Id").alias("accountId"),pl.col("Id").alias("CustomerId"),"AccountStatus","AccountNumber","Balance","CurrencyType","BranchName","CreatedAt"
    ])
    fact_transactions= cleaned_transactions.join(cleaned_accounts.select([pl.col("Id").alias("AccountId"),pl.col("Id").alias("CustomerId")]),
                                                 on="AccountId",
                                                 how="inner")
        
    return fact_transactions,dim_accounts,dim_customers