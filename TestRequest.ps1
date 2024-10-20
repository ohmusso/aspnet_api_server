$hostName = "http://localhost:5000"
$getApiUrl = $hostName + "/getApi"
$addApiUrl = $hostName + "/addApi"

$headers = @{
  "Content-Type" = "application/json"
}

function TestGetApi{
    $params = @{
      Id = 1
      Name = ""
      IsComplete = $false
    }

    $json = ConvertTo-Json $params

    Invoke-WebRequest $getApiUrl -Method 'POST' -Headers $headers -Body $json
}

function TestSetApi{
    $params = @{
      Id = 5
      Name = "abc"
      IsComplete = $true
    }

    $json = ConvertTo-Json $params

    Invoke-WebRequest $addApiUrl -Method 'POST' -Headers $headers -Body $json
}

TestSetApi