from faker import Faker
fake = Faker()
def generate_account(customer_id):
    
    account={
        "AccountNumber": fake.bban(),
        "AccountType": fake.random_element(elements=('Savings', 'Checking', 'Credit')),
        "Balance": round(fake.pyfloat(left_digits=5, right_digits=2, positive=True), 2),
        "CurrencyType": fake.currency_code(),
        "CreatedAt": fake.date_time_this_decade().strftime('%Y-%m-%d %H:%M:%S'),
        "UpdatedAt": fake.date_time_this_decade().strftime('%Y-%m-%d %H:%M:%S'),
        "BranchName": fake.company(),
        "CustomerID": customer_id,
        "AccountStatus": fake.random_element(elements=('Active', 'Inactive', 'Closed')),
    }
    return account
