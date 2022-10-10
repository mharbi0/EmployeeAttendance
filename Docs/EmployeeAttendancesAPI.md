# EmployeeAttendance API

- EmployeeAttendance API
  - CheckIn
    - Request
    - Response
  - CheckOut
    - Request
    - Response
  - View EmployeeAttendance
    - Request
    - Response


## CheckIn

### Request

```js
POST /EmployeeAttendances/CheckIn
```

```json
{
    "EmployeeId": "1",
    "CheckIn": "12/20/2015 7:50:30 AM",
}
```

EmployeeId,
CheckIn,
CheckOut,
LateCheckIn,
EarlyCheckOut


int EmployeeId
DateTime CheckIn
DateTime? CheckOut
bool LateCheckIn
bool EarlyCheckOut

### Response

```js
201 Added
```

```yml
Location: {{host}}/EmployeeAttendances/{{EmployeeId}, {CheckIn}}
```

```json
{
  "Status": "Successful",
  {
      "EmployeeId": "1",
      "CheckIn": "12/20/2015 7:50:30 AM",
      "CheckOut": null,
      "LateCheckIn": false,
      "EarlyCheckOut": false
  }
}
```

## CheckOut

### Request

```js
PUT /EmployeeAttendances/CheckOut/{{EmployeeId}, {CheckIn}}
```

```json
{
    "EmployeeId": "1",
    "CheckIn": "12/20/2015 7:50:30 AM",
    "CheckOut": "12/20/2015 3:50:30 PM",
}
```

### Response

```json
{
  "Status": "Successful",
  {
      "EmployeeId": "1",
      "CheckIn": "12/20/2015 7:50:30 AM",
      "CheckOut": null,
      "LateCheckIn": false,
      "EarlyCheckOut": false
  }
}
```

```js
201 Added
```

```yml
Location: {{host}}/EmployeeAttendances/{{EmployeeId}, {CheckIn}}
```

## Get EmployeeAttendance

### Request

```js
GET /EmployeeAttendances/{{EmployeeId}, {CheckIn}}
```

### Response

```js
200 Ok
```

```json
{
  {
      "EmployeeId": "1",
      "CheckIn": "12/20/2015 7:50:30 AM",
      "CheckOut": null,
      "LateCheckIn": false,
      "EarlyCheckOut": false
  }
}
```

## Get EmployeeAttendance List by EmployeeId

### Request

```js
GET /EmployeeAttendances/Employee/{{EmployeeId}}
```

### Response

```js
200 Ok
```

```json
{
  {
      "EmployeeId": "1",
      "CheckIn": "12/20/2015 7:50:30 AM",
      "CheckOut": null,
      "LateCheckIn": false,
      "EarlyCheckOut": false
  }
}
```

## Get EmployeeAttendance List 

### Request

```js
GET /EmployeeAttendances/Employee/
```

### Response

```js
200 Ok
```

```json
{
  {
      "EmployeeId": "1",
      "CheckIn": "12/20/2015 7:50:30 AM",
      "CheckOut": null,
      "LateCheckIn": false,
      "EarlyCheckOut": false
  }
}
```