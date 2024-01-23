# 🚀 Console App with AWS SQS Integration
## Overview

This .NET 8 console application is a powerful tool that allows you to send and receive messages to and from AWS Simple Queue Service (SQS). It's built with simplicity and efficiency in mind, leveraging the capabilities of .NET 8 and AWS SDK for .NET.

## Features

- **AWS SQS Integration**: 🔄 Seamlessly send and receive messages using the AWS SDK for .NET.
- **Secure Secrets Handling**: 🔐 Utilize an `appsettings.json` file to manage and securely store your AWS credentials.

## Getting Started

### Prerequisites

Before you begin, make sure you have the following installed:

- [.NET SDK 8](https://dotnet.microsoft.com/download)
- [AWS CLI](https://aws.amazon.com/cli/) configured with your credentials.

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/guilhermebernava/SqsSender.git
   ```

2. Navigate to the project directory:

   ```bash
   cd your-repo
   ```

3. Restore dependencies:

   ```bash
   dotnet restore
   ```

4. Configure AWS credentials in `appsettings.json`:

   ```json
   {
     "AWS": {
       "AccessKeyId": "YOUR_ACCESS_KEY_ID",
       "SecretAccessKey": "YOUR_SECRET_ACCESS_KEY",
       "Region": "YOUR_AWS_REGION"
     },
     "SQS": {
      "QueueUrl": "YOUR_QUEUE_URL"
    }
   }
   ```

5. Run the application:

   ```bash
   dotnet run
   ```

## Usage

### Sending Messages
To send a message to SQS, you should write the message in console.

### Receiving Messages
To receive messages from SQS, is just not end the program after sended a message.

## Configuration
All configuration settings are managed in the `appsettings.json` file. Update the file to include your AWS credentials and other configuration options.
