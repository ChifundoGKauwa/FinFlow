from src.customers import generate_customer
from src.transactions import generate_transaction
from src.accounts import generate_account
import requests

def post_and_report(name, url,payload):
    try:
        resp = requests.post(url,json=payload,timeout=10)
        print(f"{name}:{resp.status_code}")
        if resp.ok:
            data= resp.json()
            print(data)
            return data
        else:
            print(resp.text)
            return None
    except requests.exceptions.RequestException as e:
        print(f"{name} failed:{e}")
        return None

##create customer data
customer = generate_customer()
created_customer = post_and_report("customer","http://localhost:5140/customers",customer)
if created_customer is None:
    exit()
customer_id= created_customer.get("id")

##create account data
account = generate_account(customer_id)
created_account = post_and_report("account","http://localhost:5140/accounts",account)
if created_account is None:
    exit()
account_id = created_account.get("id")

##create transaction data
transaction = generate_transaction(account_id)
created_transaction = post_and_report("transaction","http://localhost:5140/transactions",transaction)


