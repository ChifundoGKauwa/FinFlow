import polars as pl

def gold_layer(cleaned_accounts:pl.DataFrame,cleaned_transactions:pl.DataFrame,cleaned_customers:pl.DataFrame):
        dim_customer = (
            cleaned_customers
            .select([
                "Id",
                "FirstName",
                "LastName",
                "Email",
                "Gender",
                "PhoneNumber",
                "DateOfBirth",
                "CreatedAt"
            ])
            .with_row_index("CustomerKey", offset=1)
            .rename({"Id": "CustomerId"})
        )
        


        dim_account = (
    cleaned_accounts
    .select([
        "Id",
        "CustomerId",
        "AccountNumber",
        "AccountType",
        "AccountStatus",
        "Balance",
        "CurrencyType",
        "BranchName"
    ])
    .with_row_index("AccountKey", offset=1)
    .rename({"Id":"AccountId"})
    )
        dim_date = (
            cleaned_transactions
            .select("TransactionTimestamp")
            .unique()
            .with_columns([
                pl.col("TransactionTimestamp").dt.date().alias("Date"),
                pl.col("TransactionTimestamp").dt.year().alias("Year"),
                pl.col("TransactionTimestamp").dt.quarter().alias("Quarter"),
                pl.col("TransactionTimestamp").dt.month().alias("Month"),
                pl.col("TransactionTimestamp").dt.month().cast(pl.String).alias("MonthNumber"),
                pl.col("TransactionTimestamp").dt.week().alias("Week"),
                pl.col("TransactionTimestamp").dt.weekday().alias("Weekday"),
                pl.col("TransactionTimestamp").dt.ordinal_day().alias("DayOfYear")
            ])
            .with_row_index("DateKey",offset=1)
        )
        dim_currency = (
            cleaned_transactions
            .select("CurrencyType")
            .unique()
            .sort("CurrencyType")
            .with_row_index("CurrencyKey",offset=1)
        )    

        dim_transaction_type = (
            cleaned_transactions
            .select("TransactionType")
            .unique()
            .sort("TransactionType")
            .with_row_index("TransactionTypeKey",offset=1)
        )

        dim_channel = (
            cleaned_transactions
            .select("Channel")
            .unique()
            .sort("Channel")
            .with_row_index("ChannelKey",offset=1)
        )

        dim_transaction_status = (
            cleaned_transactions
            .select("TransactionStatus")
            .unique()
            .sort("TransactionStatus")
            .with_row_index("TransactionStatusKey",offset=1)
        )

        dim_branch = (
            cleaned_accounts
            .select("BranchName")
            .unique()
            .sort("BranchName")
            .with_row_index("BranchKey",offset=1)
        )

        account_lookup = cleaned_accounts.select([
            pl.col("Id").alias("AccountId"),
            "CustomerId",
            "BranchName",
            "CurrencyType"
        ])

        fact_transactions = (
            cleaned_transactions
            .join(account_lookup, on="AccountId")
            .select([
                pl.col("Id").alias("TransactionId"),
                "CustomerId",
                "AccountId",
                "TransactionTimestamp",
                "TransactionReference",
                "Amount",
                "TransactionType",
                "Channel",
                "TransactionStatus",
                "CurrencyType",
                "BranchName"
            ])
        )
        return fact_transactions,dim_account,dim_customer,dim_date,dim_branch,dim_channel,dim_transaction_status,dim_transaction_type,dim_currency