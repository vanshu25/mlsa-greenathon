# API

## Submit Business
```http
POST /api/SubmitBusiness
```

This route adds a new company to the database. Note that the company won't show up immediately before it's manually approved.

- Content-Type: `multipart/form-data`
- Required parameters:
  - `name`: the company's name
  - `industry`: the company's industry
  - `missionStatement`: their mission statement (max. 1000 characters)
  - `addressLine`: the company's address line (street name + number)
  - `town`: the town
  - `zipCode`: the ZIP code
  - `countryIsoCode`: the country's ISO 3166-1 Code 
  - `logo`: file (max. 2 MB; must be PNG; content-type: `image/png`)
- Returns: `201 Created`