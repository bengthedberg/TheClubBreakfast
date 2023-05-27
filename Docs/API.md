# The Club Breakfast API

- [The Club Breakfast API](#the-club-breakfast-api)
  - [Create Breakfast](#create-breakfast)
    - [Create Breakfast Request](#create-breakfast-request)
    - [Create Breakfast Response](#create-breakfast-response)
      - [Header](#header)
      - [Body](#body)
  - [Get Breakfast](#get-breakfast)
    - [Get Breakfast Request](#get-breakfast-request)
    - [Get Breakfast Response](#get-breakfast-response)
      - [Body](#body-1)
  - [Update Breakfast](#update-breakfast)
    - [Update Breakfast Request](#update-breakfast-request)
    - [Update Breakfast Response](#update-breakfast-response)
      - [Header](#header-1)
  - [Delete Breakfast](#delete-breakfast)
    - [Delete Breakfast Request](#delete-breakfast-request)
    - [Delete Breakfast Response](#delete-breakfast-response)

## Create Breakfast

### Create Breakfast Request

```js
POST /breakfasts
```

```json
{
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy breakfast..",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```

### Create Breakfast Response

```js
201 Created
```

#### Header

```yml
Location: {{host}}/Breakfasts/{{id}}
```
#### Body

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy breakfast..",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "lastModifiedDateTime": "2022-04-06T12:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```

## Get Breakfast

### Get Breakfast Request

```js
GET /breakfasts/{{id}}
```

### Get Breakfast Response

```js
200 Ok
```

#### Body

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy breakfast..",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "lastModifiedDateTime": "2022-04-06T12:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```

## Update Breakfast

### Update Breakfast Request

```js
PUT /breakfasts/{{id}}
```

```json
{
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy breakfast..",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```

### Update Breakfast Response

```js
204 No Content
```

or

```js
201 Created
```
#### Header

```yml
Location: {{host}}/Breakfasts/{{id}}
```

## Delete Breakfast

### Delete Breakfast Request

```js
DELETE /breakfasts/{{id}}
```

### Delete Breakfast Response

```js
204 No Content
```