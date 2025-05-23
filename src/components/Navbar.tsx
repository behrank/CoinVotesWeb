import * as React from "react";
import Link from "next/link";
import Image from "next/image";
import { Twitter, Linkedin } from 'lucide-react';

export function Navbar() {
  return (
    <header className="fixed top-0 z-50 w-full px-6 py-3">
      <div className="mx-auto max-w-5xl">
        <nav 
          className="flex items-center justify-between h-[56px] px-6"
          style={{
            borderWidth: '1px',
            borderStyle: 'solid',
            borderColor: 'rgba(255, 255, 255, 0.04)',
            backdropFilter: 'blur(12px)',
            backgroundColor: 'rgba(255, 255, 255, 0.04)',
            borderRadius: '16px',
            transform: 'none',
            transformOrigin: '50% 50% 0px',
            opacity: 1
          }}
        >
          <Link href="/" className="flex items-center space-x-3">
            <Image src="/img/logo.webp" alt="CoinInsight Logo" width={36} height={36} className="rounded-lg" />
            <span className="font-bold text-white text-xl">CoinInsight</span>
          </Link>
          
          <div className="hidden md:flex items-center space-x-6">
            <Link 
              href="/#features" 
              className="text-sm font-medium text-gray-200 transition-colors hover:text-white"
            >
              Features
            </Link>
            <Link href="/#download" className="text-sm font-medium text-gray-200 transition-colors hover:text-white">
              Download
            </Link>
            <Link href="/contact" className="text-sm font-medium text-gray-200 transition-colors hover:text-white">
              Contact Us
            </Link>
            <Link href="/terms" className="text-sm font-medium text-gray-200 transition-colors hover:text-white">
              Terms of Service
            </Link>
            <Link href="/privacy" className="text-sm font-medium text-gray-200 transition-colors hover:text-white">
              Privacy Policy
            </Link>
            <div className="flex items-center space-x-4 ml-4 border-l border-gray-700 pl-4">
              <a 
                href="https://apps.apple.com/us/app/coininsight/id6476925677" 
                target="_blank" 
                rel="noopener noreferrer" 
                className="text-gray-400 hover:text-white transition-colors"
                aria-label="Download on App Store"
              >
                <svg width="18" height="18" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                  <path d="M14.94 5.19A4.38 4.38 0 0 0 16 2a4.38 4.38 0 0 0-3 1.52 4.09 4.09 0 0 0-1 3.09 3.47 3.47 0 0 0 2.94-1.42zm2.52 7.44a4.51 4.51 0 0 1 2.16-3.81 4.66 4.66 0 0 0-3.66-2c-1.56-.16-3 .91-3.83.91-.83 0-2-.89-3.3-.87a4.92 4.92 0 0 0-4.14 2.53C2.93 12.45 4.24 17 6 19.47c.8 1.21 1.8 2.58 3.12 2.53 1.32-.05 1.75-.82 3.28-.82 1.53 0 2 .82 3.3.79 1.3-.03 2.22-1.24 3.06-2.45a11 11 0 0 0 1.38-2.85 4.41 4.41 0 0 1-2.68-4.04z" fill="currentColor"/>
                </svg>
              </a>
              <a 
                href="https://play.google.com/store/apps/details?id=com.bemobile.coininsight" 
                target="_blank" 
                rel="noopener noreferrer" 
                className="text-gray-400 hover:text-white transition-colors"
                aria-label="Get it on Google Play"
              >
                <svg width="18" height="18" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                  <path d="M3.609 2.5l8.263 8.264-8.263 8.263a1.914 1.914 0 01-.359-1.207V3.707c0-.47.137-.89.359-1.207zm9.5 9.5l2.789 2.789-10.535 6.11a1.914 1.914 0 01-1.07.172l8.816-9.071zm3.872 2.182l-2.582-1.496 2.582-1.496 2.582 1.496-2.582 1.496zm-1.318-2.789l-2.789-2.789 8.816-9.071a1.914 1.914 0 011.07.172l-7.097 11.688z" fill="currentColor"/>
                </svg>
              </a>
              <div className="h-5 w-px bg-gray-700" />
              <a 
                href="https://x.com/coininsightapp" 
                target="_blank" 
                rel="noopener noreferrer" 
                className="text-gray-400 hover:text-white transition-colors"
                aria-label="Follow us on X (Twitter)"
              >
                <Twitter size={18} />
              </a>
              <a 
                href="https://www.linkedin.com/company/coininsight" 
                target="_blank" 
                rel="noopener noreferrer" 
                className="text-gray-400 hover:text-white transition-colors"
                aria-label="Follow us on LinkedIn"
              >
                <Linkedin size={18} />
              </a>
            </div>
          </div>
        </nav>
      </div>
    </header>
  );
} 