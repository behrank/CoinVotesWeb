'use client';

import { useAnalytics } from "@/lib/hooks/useAnalytics";

export function Analytics() {
  // Initialize analytics
  useAnalytics();
  
  // This component doesn't render anything
  return null;
} 