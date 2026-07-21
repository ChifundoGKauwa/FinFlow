from config import Data
from extract import extractor
from validate import Validation
from transform import Tranformation

data_extractor = extractor(Data)

customers = data_extractor.extract_table("Customers")
accounts = data_extractor.extract_table("Accounts")
transactions = data_extractor.extract_table("Transactions")
validated_customers=Validation(customers)
validated_accounts=Validation(accounts)
validated_transactions=Validation(transactions)
print(f"This is the validated accounts:{validated_accounts}")
print(f"this is the validated transactions:{validated_transactions}")
print(f"This is the validated customer data:{validated_customers}")
cleaned_accounts, cleaned_transactions, cleaned_customers = Tranformation(accounts, transactions, customers)


