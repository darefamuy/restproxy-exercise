# C# Kafka REST Producer

A simple .NET 10 application demonstrating a Kafka Producer using the Confluent Cloud Kafka REST API (v3).

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- A Kafka cluster on [Confluent Cloud](https://confluent.cloud/)
- A Kafka REST endpoint for your cluster

## REST API Configuration

The project uses `HTTPProducer` which interacts with Kafka via the REST Proxy. It requires the following environment variables:

- `REST_ENDPOINT`: Your Confluent Cloud REST endpoint URL.
- `CLUSTER_ID`: Your Kafka cluster ID.
- `TOPIC_NAME`: The name of the topic.
- `BASIC_AUTH`: Base64 encoded `apiKey:secret`.

### Example (Shell)

```bash
export REST_ENDPOINT="https://pkc-xxxxx.us-east-1.aws.confluent.cloud:443"
export CLUSTER_ID="lkc-xxxxx"
export TOPIC_NAME="pharma-products"
export BASIC_AUTH="QVBJX0tFWTpBUElfU0VDUkVU"
dotnet run
```

## Project Structure

- `Program.cs`: The entry point that runs the HTTP producer.
- `HTTPProducer.cs`: Produces records using the Confluent Cloud Kafka REST API (v3).
- `KafkaCsharp.csproj`: Project file with dependencies.
- `docker-compose.yaml`: Local Kafka cluster setup (Optional).

## How to Run

1.  **Restore dependencies:**
    ```bash
    dotnet restore
    ```

2.  **Build the project:**
    ```bash
    dotnet build
    ```

3.  **Run the application:**
    ```bash
    dotnet run
    ```

The application will produce a message to the specified topic using the REST API.

## Sample Data

The producer sends a JSON payload representing an order:

```json
{
  "orderId": 1001,
  "customerId": "C-8743",
  "drugCode": "AMOX500",
  "quantity": 2,
  "status": "DISPENSED"
}
```
