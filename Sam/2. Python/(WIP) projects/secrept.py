import secrets
import string

source = string.ascii_uppercase + "example"
seed = ''.join(secrets.choice(source) for i in range(81))

print(seed)
