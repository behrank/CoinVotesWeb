#!/bin/bash

# Exit on error
set -e

echo "🚀 Starting deployment..."

# Pull latest changes
echo "📥 Pulling latest changes..."
git pull origin master

# Install dependencies
echo "📦 Installing dependencies..."
npm ci

# Build the application
echo "🏗️ Building the application..."
npm run build

# Start/Reload PM2 process
echo "🔄 Starting/Reloading PM2 process..."
pm2 reload ecosystem.config.js || pm2 start ecosystem.config.js

# Save PM2 process list
echo "💾 Saving PM2 process list..."
pm2 save

# Configure nginx if not already configured
if [ ! -f /etc/nginx/sites-available/coinvotesweb ]; then
    echo "🔧 Configuring Nginx..."
    sudo cp nginx.conf /etc/nginx/sites-available/coinvotesweb
    sudo ln -s /etc/nginx/sites-available/coinvotesweb /etc/nginx/sites-enabled/
    sudo nginx -t && sudo systemctl reload nginx
fi

# Verify deployment
echo "✅ Verifying deployment..."
sleep 5
if curl -f http://localhost:5005 &>/dev/null; then
    echo "✨ Application is running successfully!"
else
    echo "❌ Application failed to start"
    pm2 logs coininsightweb --lines 50
    exit 1
fi

# Cleanup
echo "🧹 Cleaning up..."
rm -rf .next/cache
npm cache clean --force

echo "✅ Deployment completed successfully!" 