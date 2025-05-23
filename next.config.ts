import type { NextConfig } from "next";
import type { Configuration as WebpackConfig } from 'webpack';

const nextConfig: NextConfig = {
  poweredByHeader: false,
  compress: true,
  
  // Cache build output
  output: 'standalone',
  
  // Optimize images
  images: {
    formats: ['image/avif', 'image/webp'],
    deviceSizes: [640, 750, 828, 1080, 1200, 1920, 2048, 3840],
    imageSizes: [16, 32, 48, 64, 96, 128, 256, 384],
    minimumCacheTTL: 60,
  },

  // Configure webpack for better caching
  webpack: (config: WebpackConfig, { dev, isServer }: { dev: boolean; isServer: boolean }) => {
    // Optimize CSS
    if (!dev && !isServer) {
      config.optimization = {
        ...config.optimization,
        runtimeChunk: 'single',
        splitChunks: {
          chunks: 'all',
          maxInitialRequests: 25,
          minSize: 20000,
          cacheGroups: {
            default: false,
            vendors: false,
            commons: {
              name: 'commons',
              chunks: 'all',
              minChunks: 2,
              reuseExistingChunk: true,
            },
          },
        },
      };
    }
    return config;
  },

  // Configure build output
  experimental: {
    optimizeCss: true,
  },

  // Configure Turbopack
  turbopack: {
    rules: {
      '*.js': ['swc'],
      '*.ts': ['swc'],
      '*.tsx': ['swc'],
    },
  },
};

export default nextConfig;
