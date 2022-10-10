# Justification /API
- Justification /API
    - Add Justification
        - Request
        - Reply
    - Get Justification
        - Request
        - Response
    - Accept Justification
        - Request
        - Response


<!-- int JustificationId,
DateTime DateCreated,
int EmployeeId,
DateTime CheckIn,
string Reason ,
bool Accepted -->

## Add Justification

### Request

```js
POST /API/Justifications
```

```json
{
    "EmployeeId": "1",
    "CheckIn": "12/20/2015 7:50:30 AM",
    "Reason": "Some reason...",
    
}
```

### Response

```js
201 Added
```

```yml
Location: {{host}}/API/Justifications/{{id}}
```

```json
{
    "JustificationId": "1",
    "DateCreated": "15/20/2015 10:54:17 AM",
    "EmployeeId": "1",
    "CheckIn": "12/20/2015 7:50:30 AM",
    "Reason": "Some reason...",
    "Accepted": false
}
```

## Get Justification by ID

### Request

```js
GET /API/Justifications/{{id}}
```

### Response

```js
200 Ok
```

```json
{
    "JustificationId": "1",
    "DateCreated": "15/20/2015 10:54:17 AM",
    "EmployeeId": "1",
    "CheckIn": "12/20/2015 7:50:30 AM",
    "Reason": "Some reason...",
    "Accepted": false
}
```

## GET /API/Justifications/Employee/{{id}}
### Request

```js
GET /API/Justifications/Employee/{{id}}
```

### Response

```js
200 Ok
```

```json
{
    {
        "JustificationId": "1",
        "DateCreated": "15/20/2015 10:54:17 AM",
        "EmployeeId": "1",
        "CheckIn": "12/20/2015 7:50:30 AM",
        "Reason": "Some reason...",
        "Accepted": false
    },
    {
        "JustificationId": "100",
        "DateCreated": "15/20/2015 10:54:17 AM",
        "EmployeeId": "1",
        "CheckIn": "12/20/2015 7:50:30 AM",
        "Reason": "Another reason...",
        "Accepted": false
    },
    .
    .
    .
}
````

## Accept Justification

### Request

```js
PUT /API/Justifications/{{id}}
```

```json
{
    "JustificationId": "1",
    "DateCreated": "15/20/2015 10:54:17 AM",
    "EmployeeId": "1",
    "CheckIn": "12/20/2015 7:50:30 AM",
    "Reason": "Some reason...",
    "Accepted": true
}
```

### Response

```js
204 No Content
```

or

```js
201 Addd
```

```yml
Location: {{host}}/API/Justifications/{{id}}
```