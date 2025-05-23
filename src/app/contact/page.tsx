import * as React from "react";
import { Navbar } from "@/components/Navbar";
import { Card } from "@/components/ui/card";
import Link from "next/link";

export default function ContactPage() {
  return (
    <>
      <Navbar />
      <main 
        className="flex min-h-screen flex-col pt-24"
        style={{
          backgroundColor: '#070707'
        }}
      >
        <div className="container mx-auto px-4 py-12">
          <div className="max-w-3xl mx-auto">
            <div className="text-center mb-12">
              <h1 className="text-4xl font-bold text-white mb-4">Contact Us</h1>
              <p className="text-gray-400 text-lg">
                We're here to help with any questions you might have
              </p>
            </div>

            <Card 
              className="p-8"
              style={{
                background: 'linear-gradient(90deg, rgb(26, 26, 26) 0%, rgb(8, 8, 8) 100%)',
                borderRadius: '28px',
                borderColor: '#141414'
              }}
            >
              <div className="space-y-8">
                <div className="space-y-4">
                  <p className="text-gray-200 text-lg">
                    You can directly send us an email for questions using this email address:
                  </p>
                  <a 
                    href="mailto:info@coininsight.app"
                    className="text-xl font-semibold text-white hover:text-blue-400 transition-colors"
                  >
                    info@coininsight.app
                  </a>
                </div>

                <div className="space-y-4">
                  <p className="text-gray-200 text-lg">
                    You may also use our official X account for support:
                  </p>
                  <a 
                    href="https://x.com/coininsightapp"
                    target="_blank"
                    rel="noopener noreferrer"
                    className="text-xl font-semibold text-white hover:text-blue-400 transition-colors"
                  >
                    Official X page
                  </a>
                </div>
              </div>
            </Card>
          </div>
        </div>
      </main>
    </>
  );
} 