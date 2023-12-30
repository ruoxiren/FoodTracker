Notes ahead:
- using 127.0.0.1:5000 as placeholder for the actual host.


## API for meals.

### Get meals based on parameters:

```
GET http://127.0.0.1:5000/meals?startDatetime=2023-01-14T09:00:05.123Z&endDatetime=2023-01-16T09:00:05.123Z
```

Example request body:
```
nothing
```

Example response body:
```
// meals in the datetime range.
{
   "meals": [
        {
            "id": "93a25855-ae1f-42b0-929f-6d6279d719ad",
            "name": "lunch1",
            "datetime": "2023-01-14T09:00:05.123Z",
            "totalCalories": 123.46,
            "mealItems": [
                {"name":"apple","calories":"23.46","servings":"2","servingType":"kg"}
                {"name":"shit","calories":"100.0","servings":"300","servingType":"g"}
            ]
        },
        ...,
    ],
}
```

### Add new meals

```
POSt http://127.0.0.1:5000/meals
```

Example request
```
{
   "meals": [
        {
            "id": "93a25855-ae1f-42b0-929f-6d6279d719ad",
            "name": "lunch1",
            "datetime": "2023-01-14T09:00:05.123Z",
            "totalCalories": 100.0,
            "mealItems": [
                {"name":"shit","calories":"100.0","servings":"300","servingType":"g"}
            ]
        },
        {
            "id": "82a25855-ae1f-42b0-929f-6d6279d719ad",
            "name": "dinner1",
            "datetime": "2023-01-14T18:00:05.123Z",
            "totalCalories": 100.0,
            "mealItems": [
                {"name":"shit","calories":"100.0","servings":"300","servingType":"g"}
            ]
        },
        ...,
    ],
}
```

Response code:
```
success:
200: ok

others are default.
```

Example response body:
```
nothing
```


### Update values of some fields

```
PATCH http://127.0.0.1:5000/meals
```

Example request, to update meal with `"id": "93a25855-ae1f-42b0-929f-6d6279d719ad"` name to "lunch2".
```
{
   "meals": [
        {
            "id": "93a25855-ae1f-42b0-929f-6d6279d719ad",
            "name": "lunch2",
        },
        ...,
    ],
}
```

Response code:
```
success:
200: ok
204: no content, if no meal found for patching

failed:
?: failed to update.

others are default.
```

Example response body:
```
nothing
```

### Delete some of the meals

```
DELTE http://127.0.0.1:5000/meals
```

Example request body, 
```
{
   "meals": [
        {
            "id": "93a25855-ae1f-42b0-929f-6d6279d719ad",
        },
        ...,
    ],
}
```

Response code: 
```
success:
200: ok
204: no content, if no meal found for deleting 

failed:
?: failed to delete.

others are default.
```

Example response body:
```
nothing
```


## API for recipes.

### Get recipes based on parameters:

```
GET http://127.0.0.1:5000/recipes?startDatetime=2023-01-14T09:00:05.123Z&endDatetime=2023-01-16T09:00:05.123Z
```

Example request body:
```
nothing
```

Example response body:
```
// recipes in the datetime range.
{
   "recipes": [
        {
            "id": "93a25855-ae1f-42b0-929f-6d6279d719ad",
            "name": "apple",
            "calories": 1.2,
            "servingType": "PerGram",
        },
        ...,
    ],
}
```

### Add new recipes

```
POSt http://127.0.0.1:5000/recipes
```

Example request

```
{
   "recipes": [
        {
            "id": "93a25855-ae1f-42b0-929f-6d6279d719ad",
            "name": "apple",
            "calories": 1.2,
            "servingType": "PerGram",
        },
        {
            "id": "99a25855-ae1f-42b0-929f-6d6279d719ad",
            "name": "apple",
            "calories": 1.2,
            "servingType": "PerServing",
        },
        ...,
    ],
}
```

Response code:
```
success:
200: ok

others are default.
```

Example response body:
```
nothing
```

### Update values of some fields

```
PATCH http://127.0.0.1:5000/recipes
```

Example request, to update recipe with `"id": "93a25855-ae1f-42b0-929f-6d6279d719ad"` name to "shit".

```
{
   "recipes": [
        {
            "id": "93a25855-ae1f-42b0-929f-6d6279d719ad",
            "name": "shit",
        },
        ...,
    ],
}
```

Response code:
```
success:
200: ok
204: no content, if no recipe found for patching

failed:
?: failed to update.

others are default.
```

Example response body:

```
nothing
```

### Delete some of the recipes

```
DELTE http://127.0.0.1:5000/recipes
```

Example request body, 
```
{
   "recipes": [
        {
            "id": "93a25855-ae1f-42b0-929f-6d6279d719ad",
        },
        ...,
    ],
}
```

Response code: 
```
success:
200: ok
204: no content, if no recipe found for deleting 

others are default.
```

Example response body:
```
nothing
```


