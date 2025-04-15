-- Users table indexes
CREATE INDEX IF NOT EXISTS idx_users_created_at ON "Users" ("CreatedAt");
CREATE INDEX IF NOT EXISTS idx_users_email ON "Users" ("Email") WHERE "Email" IS NOT NULL;

-- Devices table indexes
CREATE INDEX IF NOT EXISTS idx_devices_user_id ON "Devices" ("UserId");
CREATE INDEX IF NOT EXISTS idx_devices_created_at ON "Devices" ("CreatedAt");
CREATE INDEX IF NOT EXISTS idx_devices_updated_at ON "Devices" ("UpdatedAt");
CREATE INDEX IF NOT EXISTS idx_devices_device_type ON "Devices" ("DeviceType");
CREATE INDEX IF NOT EXISTS idx_devices_device_id ON "Devices" ("DeviceId");

-- UpDownVotes table indexes
CREATE INDEX IF NOT EXISTS idx_updownvotes_user_id ON "UpDownVotes" ("UserId");
CREATE INDEX IF NOT EXISTS idx_updownvotes_poll_id ON "UpDownVotes" ("PollId");
CREATE INDEX IF NOT EXISTS idx_updownvotes_created_at ON "UpDownVotes" ("CreatedAt");
CREATE INDEX IF NOT EXISTS idx_updownvotes_symbol_id ON "UpDownVotes" ("SymbolID");
CREATE INDEX IF NOT EXISTS idx_updownvotes_user_symbol ON "UpDownVotes" ("UserId", "SymbolID");
CREATE INDEX IF NOT EXISTS idx_updownvotes_value ON "UpDownVotes" ("Value");

-- Add partial indexes for common queries
CREATE INDEX IF NOT EXISTS idx_devices_online ON "Devices" ("IsOnline") WHERE "IsOnline" = true;
CREATE INDEX IF NOT EXISTS idx_updownvotes_upvotes ON "UpDownVotes" ("Value") WHERE "Value" = true;
CREATE INDEX IF NOT EXISTS idx_updownvotes_downvotes ON "UpDownVotes" ("Value") WHERE "Value" = false;

-- Add comment to indexes for documentation
COMMENT ON INDEX idx_users_created_at IS 'Index for sorting and filtering users by creation date';
COMMENT ON INDEX idx_users_email IS 'Index for user email lookups and uniqueness constraint';
COMMENT ON INDEX idx_devices_user_id IS 'Index for device lookups by user';
COMMENT ON INDEX idx_devices_created_at IS 'Index for sorting and filtering devices by creation date';
COMMENT ON INDEX idx_devices_updated_at IS 'Index for sorting and filtering devices by last update';
COMMENT ON INDEX idx_devices_device_type IS 'Index for filtering devices by type';
COMMENT ON INDEX idx_devices_device_id IS 'Index for device ID lookups';
COMMENT ON INDEX idx_updownvotes_user_id IS 'Index for vote lookups by user';
COMMENT ON INDEX idx_updownvotes_poll_id IS 'Index for vote lookups by poll';
COMMENT ON INDEX idx_updownvotes_created_at IS 'Index for sorting and filtering votes by creation date';
COMMENT ON INDEX idx_updownvotes_symbol_id IS 'Index for vote lookups by symbol';
COMMENT ON INDEX idx_updownvotes_user_symbol IS 'Composite index for user-specific symbol vote lookups';
COMMENT ON INDEX idx_updownvotes_value IS 'Index for filtering votes by value (up/down)'; 