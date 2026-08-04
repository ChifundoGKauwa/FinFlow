from config import Data
from extract import extractor
from validate import Validation
from transform import Tranformation
from load.parquet import ParquetLoader
from gold import gold_layer
data_extractor = extractor(Data)
loader = ParquetLoader()

#extracting data from database 
customers = data_extractor.extract_table("Customers")
accounts = data_extractor.extract_table("Accounts")
transactions = data_extractor.extract_table("Transactions")

#valiadating extracted data
validated_customers=Validation(customers)
validated_accounts=Validation(accounts)
validated_transactions=Validation(transactions)

print(f"This is the validated accounts:{validated_accounts}")
print(f"this is the validated transactions:{validated_transactions}")
print(f"This is the validated customer data:{validated_customers}")

#loading raw data into bronze
loader.write(customers,"bronze","customers")
loader.write(transactions,"bronze","transactions")
loader.write(accounts,"bronze","accounts")

#cleaning data
cleaned_accounts, cleaned_transactions, cleaned_customers = Tranformation(accounts, transactions, customers)

#loading cleaned data into silver
loader.write(cleaned_accounts,"silver","cleaned_accounts")
loader.write(cleaned_customers,"silver","cleaned_customers")
loader.write(cleaned_transactions,"silver","cleaned_transaction")


fact_transactions,dim_account,dim_customer,dim_date,dim_branch,dim_channel,dim_transaction_status,dim_transaction_type,dim_currency= gold_layer(
    cleaned_accounts, 
    cleaned_transactions, 
    cleaned_customers
)
# loading into gold
# loading into gold

loader.write(
    dim_account,
    "gold",
    "dim_accounts"
)

loader.write(
    dim_customer,
    "gold",
    "dim_customers"
)

loader.write(
    dim_date,
    "gold",
    "dim_date"
)

loader.write(
    dim_branch,
    "gold",
    "dim_branch"
)

loader.write(
    dim_channel,
    "gold",
    "dim_channel"
)

loader.write(
    dim_transaction_status,
    "gold",
    "dim_transaction_status"
)

loader.write(
    fact_transactions,
    "gold",
    "fact_transactions"
)



