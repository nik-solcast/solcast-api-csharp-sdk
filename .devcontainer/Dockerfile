# Base image with .NET SDK 8.0 (and runtime)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base

# Set the working directory inside the container
WORKDIR /workspace

# Install any additional tools if needed (optional)
RUN apt-get update && apt-get install -y \
    curl \
    git \
    && rm -rf /var/lib/apt/lists/*

# Default command
CMD [ "bash" ]
