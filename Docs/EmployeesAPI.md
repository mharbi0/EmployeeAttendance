# Employees API

- Employee API
  - Add Employee
    - Request
    - Response
  - Get Employee
    - Request
    - Response
  - Update Employee
    - Request
    - Response
  - Delete Employee
    - Request
    - Response
  - Get Employee List
    - Request
    - Respons

<!-- ================================================ -->
## Add Employee

### Request

```js
POST /Employee
```

```json
{
    "Name": "Mohammad Alharbi",
    "Admin": true,
    "Active": true,
}
```

### Response

```js
201 Added
```

```yml
Location: {{host}}/Employee/{{id}}
```

```json
{
    "Id": "1",
    "Name": "Mohammad Alharbi",
    "Admin": true,
    "Active": true,
}
```

<!-- ================================================ -->
## Get Employee

### Request

```js
GET /Employee/{{id}}
```

### Response

```js
200 Ok
```

```json
{
  "Id": "1",
  "Name": "Mohammad Alharbi",
  "Admin": true,
  "Active": true,
}
```
<!-- ================================================ -->
## Update Employee

### Request

```js
PUT /Employee/
```

```json
{
  "Id": "1",
  "Name": "Mohammad Alharbi",
  "Admin": false,
  "Active": true,
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
```json
{
  "Id": "1",
  "Name": "Mohammad Alharbi",
  "Admin": false,
  "Active": true,
}
```

```yml
Location: {{host}}/Employee/{{id}}
```
<!-- ================================================ -->
## Delete Employee

### Request

```json
{
  "Id": "1",
  "Name": "Mohammad Alharbi"
}
```

```js
DELETE /Employee/
```

### Response

```js
204 No Content
```

<!-- ================================================ -->
## Get Employee List

### Request

```js
GET /Employee/EmployeeList
```

### Response

```js
200 Ok
```

```json
{{
  "Id": "1",
  "Name": "Mohammad Alharbi",
  "Admin": true,
  "Active": true,
},
{
  "Id": "2",
  "Name": "Omar Alharbi",
  "Admin": false,
  "Active": false,
}}
```
