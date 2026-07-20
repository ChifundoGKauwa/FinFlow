# DataGenerator

A small Python utility that generates realistic fake banking data (customers, accounts, transactions) using [Faker](https://faker.readthedocs.io/) and posts it to the [FinFlow API](../FinFlow).

## Setup

```bash
python -m venv .dataGenerator
source .dataGenerator/bin/activate      # Windows: .dataGenerator\Scripts\activate
pip install -r requirements.txt
```

## Usage

Make sure the FinFlow API is running locally (see [root README](../README.md#1-run-the-api)), then:

```bash
python main.py
```

This will:
1. Generate and POST a fake customer to `/customers`
2. Generate and POST an account linked to that customer to `/accounts`
3. Generate and POST a transaction linked to that account to `/transactions`

Each step prints the HTTP status code and the response body.

## Project Structure

```
DataGenerator/
├── src/
│   ├── customers.py       # generate_customers()
│   ├── accounts.py        # generate_account(customer_id)
│   └── transactions.py    # generate_transaction(account_id)
├── main.py                 # orchestrates generation + API calls
└── requirements.txt
```

