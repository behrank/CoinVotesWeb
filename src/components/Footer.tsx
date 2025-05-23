import Link from 'next/link';
import { Twitter, Linkedin } from 'lucide-react';

export function Footer() {
  return (
    <footer className="py-8 border-t border-[#141414]" style={{ backgroundColor: '#070707' }}>
      <div className="container mx-auto px-4">
        <div className="max-w-5xl mx-auto">
          <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
            {/* Company Info */}
            <div>
              <h3 className="text-white font-semibold mb-4">CoinInsight</h3>
              <p className="text-gray-400 text-sm">
                Your smart crypto trading companion providing real-time signals and market insights.
              </p>
            </div>

            {/* Quick Links */}
            <div>
              <h3 className="text-white font-semibold mb-4">Quick Links</h3>
              <div className="flex flex-col space-y-2">
                <Link href="/#features" className="text-gray-400 hover:text-white text-sm transition-colors">
                  Features
                </Link>
                <Link href="/#download" className="text-gray-400 hover:text-white text-sm transition-colors">
                  Download
                </Link>
                <Link href="/terms" className="text-gray-400 hover:text-white text-sm transition-colors">
                  Terms of Service
                </Link>
                <Link href="/privacy" className="text-gray-400 hover:text-white text-sm transition-colors">
                  Privacy Policy
                </Link>
              </div>
            </div>

            {/* Contact */}
            <div>
              <h3 className="text-white font-semibold mb-4">Contact</h3>
              <div className="flex flex-col space-y-2">
                <a href="mailto:info@coininsight.app" className="text-gray-400 hover:text-white text-sm transition-colors">
                  info@coininsight.app
                </a>
                <div className="flex items-center space-x-6 mt-4">
                  <a 
                    href="https://x.com/coininsightapp" 
                    target="_blank" 
                    rel="noopener noreferrer" 
                    className="text-gray-400 hover:text-white transition-colors"
                    aria-label="Follow us on X (Twitter)"
                  >
                    <Twitter size={20} />
                  </a>
                  <a 
                    href="https://www.linkedin.com/company/coininsight" 
                    target="_blank" 
                    rel="noopener noreferrer" 
                    className="text-gray-400 hover:text-white transition-colors"
                    aria-label="Follow us on LinkedIn"
                  >
                    <Linkedin size={20} />
                  </a>
                </div>
              </div>
            </div>
          </div>

          <div className="mt-8 pt-8 border-t border-[#141414] text-center">
            <p className="text-gray-400 text-sm">
              © {new Date().getFullYear()} CoinInsight. All rights reserved.
            </p>
          </div>
        </div>
      </div>
    </footer>
  );
} 