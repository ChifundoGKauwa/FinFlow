from faker import Faker

fake = Faker()
def generate_customer():
 customer={
    "FirstName": fake.first_name(),
    "LastName": fake.last_name(),
    "Email": fake.email(),
    "PhoneNumber": fake.phone_number()[:20],
    "Gender": fake.random_element(elements=('Male', 'Female')),
    "DateOfBirth": fake.date_of_birth(minimum_age=18, maximum_age=90).isoformat()

    }
 return customer
