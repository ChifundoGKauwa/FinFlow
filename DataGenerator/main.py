import os
from src.customers import generate_customer
from src.transactions import generate_transaction
from src.accounts import generate_account
import requests

API_URL = os.getenv("DATA_GENERATOR_API_URL", "http://localhost:5140")

def post_and_report(name, url, payload):
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
CUSTOMERS =10

for i in range(CUSTOMERS):
    customer = generate_customer()
    created_customer = post_and_report(
        "customer",
        f"{API_URL}/customers",
        customer,
    )
    if created_customer is None:
        exit()
    customer_id = created_customer.get("id")

##create account data
ACCOUNTS = 100

for i in range(ACCOUNTS):
    account = generate_account(customer_id)
    created_account = post_and_report(
        "account",
        f"{API_URL}/accounts",
        account,
    )
    if created_account is None:
        exit()
    account_id = created_account.get("id")

##create transaction data
TRANSACTIONS = 150
for i in range(TRANSACTIONS):
    transaction = generate_transaction(account_id)
    created_transaction = post_and_report(
        "transaction",
        f"{API_URL}/transactions",
        transaction,
    )


