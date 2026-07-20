from faker import Faker
fake = Faker()
def generate_transaction(account_id):

    transaction={
        "accountId": account_id,
        "AccountNumber": fake.bban(),
        "TransactionType": fake.random_element(elements=('Deposit', 'Withdrawal', 'Transfer')),
        "Amount": round(fake.pyfloat(left_digits=5, right_digits=2, positive=True), 2),
        "CurrencyType": fake.currency_code(),
        "Channel": fake.random_element(elements=('Online', 'ATM', 'Branch')),
        "TransactionStatus": fake.random_element(elements=('Pending', 'Completed', 'Failed')),
        "Description": fake.sentence(nb_words=12),
        "transactionReference": fake.uuid4(),
        "transactionTimeStamp": fake.date_time_this_decade().astimezone().isoformat(),
    }
    return transaction
